package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.widget.Button
import android.widget.EditText
import android.widget.GridLayout
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.rentaruro.model.Car
import com.example.rentaruro.network.RetrofitClient
import kotlinx.coroutines.launch

class MainActivity : AppCompatActivity() {
  private var carsList: List<Car> = emptyList() // Store the fetched cars


  override fun onCreate(savedInstanceState: Bundle?) {
    super.onCreate(savedInstanceState)
    setContentView(R.layout.activity_main)
    val fuelLayout = findViewById<LinearLayout>(R.id.fuel_layout)
    val gearshiftLayout = findViewById<LinearLayout>(R.id.gearshift_layout)
    val aircondLayout = findViewById<LinearLayout>(R.id.aircond_status)

    val fuelText = findViewById<TextView>(R.id.fuel_type)
    val gearshiftText = findViewById<TextView>(R.id.gearshift_type)


    if (car.airCondition) {
      aircondLayout.visibility = View.VISIBLE
    } else {
      aircondLayout.visibility = View.GONE
    }
  }

    val ivProfile = findViewById<ImageView>(R.id.profile_icon)
    ivProfile.setOnClickListener {
      showAuthChoiceDialog()
    }

    val grid = findViewById<GridLayout>(R.id.gridCars)

    lifecycleScope.launch {
      try {
        carsList = RetrofitClient.apiService.listCars() // Fetch and store the car list
        displayCars(grid, carsList) // Display all cars initially
      } catch (e: Exception) {
        Toast.makeText(
          this@MainActivity,
          "Adatbetöltési hiba: ${e.localizedMessage}",
          Toast.LENGTH_LONG
        ).show()
      }
    }
  }

  private fun displayCars(grid: GridLayout, cars: List<Car>) {
    grid.removeAllViews() // Clear previous views
    cars.forEach { car ->
      val card = LayoutInflater.from(this@MainActivity)
        .inflate(R.layout.item_car, grid, false) as LinearLayout

      card.findViewById<TextView>(R.id.tvBrand).text = car.brand
      card.findViewById<TextView>(R.id.tvType).text = " (${car.type})"
      card.findViewById<TextView>(R.id.tvInfo).text = car.info
      card.findViewById<TextView>(R.id.licensePlate).text = car.licensePlate ?: "Nincs rendszám"

      card.setOnClickListener { clickedCard ->
        val clickedLicensePlateTextView = clickedCard.findViewById<TextView>(R.id.licensePlate)
        val clickedLicensePlate = clickedLicensePlateTextView.text.toString()

        // Find the car in the list with the matching license plate
        val selectedCar = carsList.find { it.licensePlate?.equals(clickedLicensePlate, ignoreCase = true) == true }

        selectedCar?.let {
          val intent = Intent(this@MainActivity, CarDetailActivity::class.java)
          intent.putExtra("carId", it.id)
          intent.putExtra("carName", "${it.brand} ${it.type}") // pass name
          intent.putExtra("fuel", it.fuel)
          intent.putExtra("gearShift", it.gearShift)
          intent.putExtra("airCondition", it.airCondition)
          intent.putExtra("price_1_5", it.OneToFive)
          intent.putExtra("price_6_14", it.SixToForteen)
          intent.putExtra("price_15_plus", it.OverForteen)
          intent.putExtra("deposit", it.Deposit)
          intent.putExtra("picture", it.picture)
          startActivity(intent)
        } ?: run {
          Toast.makeText(this@MainActivity, "Hiba: Az autó nem található a listában!", Toast.LENGTH_SHORT).show()
          Log.e("MainActivity", "Could not find car with license plate: $clickedLicensePlate")
        }
      }
      grid.addView(card)
    }
  }

  private fun showAuthChoiceDialog() {
    val dialogView = layoutInflater.inflate(R.layout.dialog_auth_choice, null)
    val dialog = AlertDialog.Builder(this)
      .setView(dialogView)
      .create()

    dialogView.findViewById<Button>(R.id.btnDialogLogin)
      .setOnClickListener {
        Log.d("MainActivity", "Bejelentkezés gomb megnyomva")
        startActivity(Intent(this, LoginActivity::class.java))
        dialog.dismiss()
      }
    dialogView.findViewById<Button>(R.id.btnDialogRegister)
      .setOnClickListener {
        Log.d("MainActivity", "Regisztráció gomb megnyomva")
        startActivity(Intent(this, RegisterActivity::class.java))
        dialog.dismiss()
      }

    dialog.show()
  }
}