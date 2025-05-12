package com.example.rentaruro


import android.app.AlertDialog
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import java.io.File
import com.bumptech.glide.Glide

class CarDetailActivity : AppCompatActivity() {

    // Ez például lehet a bejelentkezés állapotát tároló változó
    private var isLoggedIn = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.car_card)

        // Vissza gomb kezelése
        findViewById<ImageView>(R.id.back_button).setOnClickListener {
            finish()
        }

        // Cím beállítása intentből
        val carName = intent.getStringExtra("carName") ?: "Autó neve"
        findViewById<TextView>(R.id.detail_title).text =
            intent.getStringExtra("carName") ?: "Autó neve"

        findViewById<TextView>(R.id.fuel_type).text =
            intent.getStringExtra("fuel") ?: "N/A"

        findViewById<TextView>(R.id.gearshift_type).text =
            intent.getStringExtra("gearShift") ?: "N/A"

        findViewById<TextView>(R.id.aircond_status).text =
            if (intent.getBooleanExtra("airCondition", false)) "Légkondi" else "Nincs légkondi"

        findViewById<TextView>(R.id.price_1_5).text =
            "${intent.getIntExtra("price_1_5", 0)} Ft/nap"

        findViewById<TextView>(R.id.price_6_14).text =
            "${intent.getIntExtra("price_6_14", 0)} Ft/nap"

        findViewById<TextView>(R.id.price_15_plus).text =
            "${intent.getIntExtra("price_15_plus", 0)} Ft/nap"

        findViewById<TextView>(R.id.deposit_amount).text =
            "${intent.getIntExtra("deposit", 0)} Ft"

        val imageUrl = intent.getStringExtra("picture")
        val carImage = findViewById<ImageView>(R.id.big_car_image)

        // Foglalás gomb
        findViewById<Button>(R.id.btn_book_car).setOnClickListener {
            if (!isLoggedIn) {
                showBookingDialog()
            } else {
                // TODO: tovább a valós foglalási folyamathoz
            }
        }
    }

    private fun showBookingDialog() {
        // Layout betöltése
        val dialogView = LayoutInflater.from(this)
            .inflate(R.layout.foglalas, null)

        // EditText-ek lekérése (ha később ki akarod olvasni)
        val etName      = dialogView.findViewById<EditText>(R.id.et_name)
        val etPhone     = dialogView.findViewById<EditText>(R.id.et_phone)
        val etEmail     = dialogView.findViewById<EditText>(R.id.et_email)
        val etStartDate = dialogView.findViewById<EditText>(R.id.et_start_date)
        val etEndDate   = dialogView.findViewById<EditText>(R.id.et_end_date)
        val etNotes     = dialogView.findViewById<EditText>(R.id.et_notes)

        // AlertDialog összeállítása
        val dialog = AlertDialog.Builder(this)
            .setView(dialogView)
            .setPositiveButton("Küldés") { dlg, _ ->
                // Itt olvasd ki az értékeket és küldd el / ellenőrizd
                val name  = etName.text.toString()
                val phone = etPhone.text.toString()
                // ...
                dlg.dismiss()
            }
            .setNegativeButton("Mégse") { dlg, _ ->
                dlg.dismiss()
            }
            .create()

        dialog.show()
    }
}
