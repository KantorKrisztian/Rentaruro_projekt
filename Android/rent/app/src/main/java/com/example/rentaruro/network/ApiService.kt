package com.example.rentaruro.network

import com.example.rentaruro.model.Car
import retrofit2.http.GET

interface ApiService {
  @GET("cars")
  suspend fun getCars(): List<Car>
}
