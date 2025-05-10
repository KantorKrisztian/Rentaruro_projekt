package com.example.rentaruro.model

data class RegisterRequest(
    val username: String,
    val password: String,
    val realName: String,
    val address: String,
    val email: String,
    val phone: String,
    val birth: String,
    val tax: String
)
