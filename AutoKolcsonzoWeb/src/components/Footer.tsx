
import React from "react";
import { Phone, Mail, MapPin } from "lucide-react";

const Footer = () => {
  return (
    <footer className="bg-gray-100 py-8 border-t border-gray-200">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="text-center">
          <h3 className="font-semibold text-lg mb-4">Kapcsolat</h3>
          <div className="flex flex-col items-center space-y-2">
            <div className="flex items-center">
              <Phone className="h-4 w-4 mr-2" />
              <span>+36-1-555-55-55</span>
            </div>
            <div className="flex items-center">
              <Mail className="h-4 w-4 mr-2" />
              <span>info@kolcsonzo.hu</span>
            </div>
            <div className="flex items-center">
              <MapPin className="h-4 w-4 mr-2" />
              <span>Autó kölcsönző</span>
            </div>
          </div>
        </div>
        <div className="mt-8 flex justify-center">
          <div className="flex-shrink-0 flex items-center">
            <span className="text-2xl font-bold text-amber-500">AUTÓ</span>
            <span className="text-2xl font-bold text-white bg-amber-500 px-2">KÖLCSÖNZŐ</span>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
