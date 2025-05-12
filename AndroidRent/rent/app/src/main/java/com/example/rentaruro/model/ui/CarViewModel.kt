package com.example.rentaruro.model.ui

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.rentaruro.model.Car
import com.example.rentaruro.network.ApiService
import kotlinx.coroutines.launch

class CarViewModel(
    private val apiService: ApiService
) : ViewModel() {

    private val _carList = MutableLiveData<List<Car>>()
    val carList: LiveData<List<Car>> get() = _carList

    fun fetchCars() {
        viewModelScope.launch {
            try {
                val cars = apiService.listCars()
                _carList.value = cars
            } catch (e: Exception) {
                // TODO: itt kezeld a hibát (pl. külön LiveData a hibaüzeneteknek)
                e.printStackTrace()
            }
        }
    }
}
