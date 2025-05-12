package com.example.rentaruro


import android.app.AlertDialog
import android.os.Bundle
import android.view.LayoutInflater
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class CarDetailActivity : AppCompatActivity() {


    private var isLoggedIn = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.car_card)

        // Back button
        findViewById<ImageView>(R.id.back_button).setOnClickListener {
            finish()
        }

        //Set title
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

        // Rent button
        findViewById<Button>(R.id.btn_book_car).setOnClickListener {
            if (!isLoggedIn) {
                showBookingDialog()
            } else {
                // TODO: tovább a valós foglalási folyamathoz
            }
        }
    }

    private fun showBookingDialog() {
        // Load layout
        val dialogView = LayoutInflater.from(this)
            .inflate(R.layout.rent, null)

        // EditTexts get content
        val etName      = dialogView.findViewById<EditText>(R.id.et_name)
        val etPhone     = dialogView.findViewById<EditText>(R.id.et_phone)
        val etEmail     = dialogView.findViewById<EditText>(R.id.et_email)
        val etStartDate = dialogView.findViewById<EditText>(R.id.et_start_date)
        val etEndDate   = dialogView.findViewById<EditText>(R.id.et_end_date)
        val etNotes     = dialogView.findViewById<EditText>(R.id.et_notes)

        val dialog = AlertDialog.Builder(this)
            .setView(dialogView)
            .setPositiveButton("Küldés") { dlg, _ ->
                val name  = etName.text.toString()
                val phone = etPhone.text.toString()
                dlg.dismiss()
            }
            .setNegativeButton("Mégse") { dlg, _ ->
                dlg.dismiss()
            }
            .create()

        dialog.show()
    }
}
