package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
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
  override fun onCreate(savedInstanceState: Bundle?) {
    super.onCreate(savedInstanceState)
    setContentView(R.layout.activity_main)

    // 1) INFORMÁCIÓK lenyíló kód
    val infoButton = findViewById<TextView>(R.id.info_button)
    val dropdown   = findViewById<LinearLayout>(R.id.info_dropdown)
    infoButton.setOnClickListener {
      dropdown.visibility = if (dropdown.visibility == GridLayout.GONE)
        GridLayout.VISIBLE else GridLayout.GONE
    }

    // 2) Profil-ikon kattintás kezelése
    val ivProfile = findViewById<ImageView>(R.id.profile_icon)
    ivProfile.setOnClickListener {
      showAuthChoiceDialog()
    }

    // 3) Autók dinamikus betöltése
    val grid = findViewById<GridLayout>(R.id.gridCars)
    lifecycleScope.launch {
      try {
        val cars: List<Car> = RetrofitClient.apiService.listCars()
        cars.forEach { car ->
          val card = LayoutInflater.from(this@MainActivity)
            .inflate(R.layout.item_car, grid, false) as LinearLayout

          card.findViewById<TextView>(R.id.tvBrand).text = "${car.brand} (${car.year})"
          card.findViewById<TextView>(R.id.tvInfo).text  = car.info
          card.findViewById<TextView>(R.id.tvPrice).text = "1–5 nap: ${car.oneToFive} Ft/nap"

          card.setOnClickListener {
            val intent = Intent(this@MainActivity, CarDetailActivity::class.java)
            intent.putExtra("carName", car.brand)
            startActivity(intent)
          }
          grid.addView(card)
        }
      } catch (e: Exception) {
        Toast.makeText(
          this@MainActivity,
          "Adatbetöltési hiba: ${e.localizedMessage}",
          Toast.LENGTH_LONG
        ).show()
      }
    }
  }

  // 4) A felugró választó dialog
  private fun showAuthChoiceDialog() {
    val dialogView = layoutInflater.inflate(R.layout.dialog_auth_choice, null)
    val dialog = AlertDialog.Builder(this)
      .setView(dialogView)
      .create()

    // Bejelentkezés gomb
    dialogView.findViewById<Button>(R.id.btnDialogLogin)
      .setOnClickListener {
        Log.d("MainActivity", "Bejelentkezés gomb megnyomva")
        startActivity(Intent(this, LoginActivity::class.java))
        dialog.dismiss()
      }
    // Regisztráció gomb
    dialogView.findViewById<Button>(R.id.btnDialogRegister)
      .setOnClickListener {
        Log.d("MainActivity", "Regisztráció gomb megnyomva")
        startActivity(Intent(this, RegisterActivity::class.java))
        dialog.dismiss()
      }

    dialog.show()
  }
}
