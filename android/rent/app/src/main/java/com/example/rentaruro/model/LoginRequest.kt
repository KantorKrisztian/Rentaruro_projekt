package com.example.rentaruro.model

data class LoginRequest(
    val loginNev: String, // Changed from loginNev to username
    val loginPassword: String
)