﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

// Services do specific things. Your code should be organized into services based upon what each service does
// This is the cryptoservice and contains code for hashing and salting of passwords
// In the future, if your application requires any other additional cryptographic functionality
// Such as encryption/decryption, that code will also go in this service.
namespace DemoApplication.Services
{
    public class CryptoService
    {
        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Combine the password and the salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[saltBytes.Length + passwordBytes.Length];

            // Copy salt and password to the combined array
            Buffer.BlockCopy(saltBytes, 0, saltedPasswordBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, saltBytes.Length, passwordBytes.Length);

            // Compute the SHA-256 hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

                // Combine the salt and the hash to store both
                byte[] hashWithSaltBytes = new byte[saltBytes.Length + hashBytes.Length];
                Buffer.BlockCopy(saltBytes, 0, hashWithSaltBytes, 0, saltBytes.Length);
                Buffer.BlockCopy(hashBytes, 0, hashWithSaltBytes, saltBytes.Length, hashBytes.Length);

                // Return the result as a Base64 string
                return Convert.ToBase64String(hashWithSaltBytes);
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // Convert the stored hashed password from Base64 string to byte array
            byte[] hashWithSaltBytes = Convert.FromBase64String(storedHashedPassword);

            // The salt is the first 16 bytes of the stored hashed password
            byte[] saltBytes = new byte[16];
            Buffer.BlockCopy(hashWithSaltBytes, 0, saltBytes, 0, saltBytes.Length);

            // The original hash is the remainder of the stored hashed password
            byte[] storedHashBytes = new byte[hashWithSaltBytes.Length - saltBytes.Length];
            Buffer.BlockCopy(hashWithSaltBytes, saltBytes.Length, storedHashBytes, 0, storedHashBytes.Length);

            // Hash the entered password with the same salt
            byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] saltedPasswordBytes = new byte[saltBytes.Length + enteredPasswordBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, saltedPasswordBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(enteredPasswordBytes, 0, saltedPasswordBytes, saltBytes.Length, enteredPasswordBytes.Length);

            // Compute the hash of the entered password with the salt
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] enteredHashBytes = sha256.ComputeHash(saltedPasswordBytes);

                // Compare the stored hash with the computed hash
                return CompareHashes(storedHashBytes, enteredHashBytes);
            }
        }

        private static bool CompareHashes(byte[] storedHash, byte[] enteredHash)
        {
            // Ensure both hashes are the same length
            if (storedHash.Length != enteredHash.Length)
            {
                return false;
            }

            // Compare each byte
            for (int i = 0; i < storedHash.Length; i++)
            {
                if (storedHash[i] != enteredHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}