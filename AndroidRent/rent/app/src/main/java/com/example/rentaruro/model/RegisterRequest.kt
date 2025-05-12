package com.example.rentaruro.model

data class RegisterRequest(
    val registerNev: String,
    val registerPassword: String,
    val registerPhone: String,
    val registerEmail: String,
    val registerName: String
)