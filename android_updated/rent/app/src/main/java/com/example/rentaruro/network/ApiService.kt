package com.example.rentaruro.network

import com.example.rentaruro.model.Car
import com.example.rentaruro.model.LoginRequest
import com.example.rentaruro.model.LoginResponse
import com.example.rentaruro.model.RegisterRequest
import com.example.rentaruro.model.RegisterResponse
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface ApiService {
    @GET("ListCars")
    suspend fun listCars(): List<Car>

    @POST("Login")
    suspend fun login(@Body req: LoginRequest): LoginResponse

    @POST("Registration")
    suspend fun register(@Body req: RegisterRequest): RegisterResponse
}
