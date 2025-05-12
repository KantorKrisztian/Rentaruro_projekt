package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.widget.Button
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
  private var carsList: List<Car> = emptyList()

  override fun onCreate(savedInstanceState: Bundle?) {
    super.onCreate(savedInstanceState)
    setContentView(R.layout.activity_main)

    // Profile Icons
    val ivProfile = findViewById<ImageView>(R.id.profile_icon)
    ivProfile.setOnClickListener {
      showAuthChoiceDialog()
    }

    // Cars View
    val grid = findViewById<GridLayout>(R.id.gridCars)
    lifecycleScope.launch {
      try {
        carsList = RetrofitClient.apiService.listCars()
        displayCars(grid, carsList)
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
    grid.removeAllViews()
    cars.forEach { car ->
      val card = LayoutInflater.from(this)
        .inflate(R.layout.item_car, grid, false) as LinearLayout

      card.findViewById<TextView>(R.id.tvBrand).text = car.brand
      card.findViewById<TextView>(R.id.tvType)?.text =
        "(${car.type})"
      card.findViewById<TextView>(R.id.tvInfo).text = car.info
      card.findViewById<TextView>(R.id.tvInfo).text =
        "1–5 nap: ${car.OneToFive} Ft/nap"

      val aircondLayout = card.findViewById<LinearLayout>(R.id.aircond_status)
      aircondLayout?.visibility =
        if (car.airCondition) View.VISIBLE else View.GONE

      card.setOnClickListener {
        val intent = Intent(this, CarDetailActivity::class.java).apply {
          putExtra("carId", car.id)
          putExtra("carName", "${car.brand} ${car.type}")
          putExtra("fuel", car.fuel)
          putExtra("gearShift", car.gearShift)
          putExtra("airCondition", car.airCondition)
          putExtra("price_1_5", car.OneToFive)
          putExtra("price_6_14", car.SixToForteen)
          putExtra("price_15_plus", car.OverForteen)
          putExtra("deposit", car.Deposit)
          putExtra("picture", car.picture)
        }
        startActivity(intent)
      }
      grid.addView(card)
    }
  }

  private fun showAuthChoiceDialog() {
    val dialogView = layoutInflater.inflate(R.layout.dialog_auth_choice, null)
    val dialog = AlertDialog.Builder(this)
      .setView(dialogView)
      .create()

    dialogView.findViewById<Button>(R.id.btnDialogLogin).setOnClickListener {
      Log.d("MainActivity", "Bejelentkezés gomb megnyomva")
      startActivity(Intent(this, LoginActivity::class.java))
      dialog.dismiss()
    }
    dialogView.findViewById<Button>(R.id.btnDialogRegister).setOnClickListener {
      Log.d("MainActivity", "Regisztráció gomb megnyomva")
      startActivity(Intent(this, RegisterActivity::class.java))
      dialog.dismiss()
    }
    dialog.show()
  }
}
