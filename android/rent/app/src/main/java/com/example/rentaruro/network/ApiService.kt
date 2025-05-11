package com.example.rentaruro.network

import com.example.rentaruro.model.Car
import com.example.rentaruro.model.LoginRequest
import com.example.rentaruro.model.LoginResponse
import com.example.rentaruro.model.RegisterRequest
import com.example.rentaruro.model.RegisterResponse
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface ApiService {
    @GET("ListCars")
    suspend fun listCars(): List<Car>

    @POST("UserLogin")
    suspend fun login(@Body req: LoginRequest): LoginResponse

    @POST("UserRegistration")
    suspend fun register(@Body req: RegisterRequest): RegisterResponse
}