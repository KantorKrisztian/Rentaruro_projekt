
import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import {CircleDot, X } from "lucide-react";
import Navbar from "@/components/Navbar";
import Footer from "@/components/Footer";
import { Button } from "@/components/ui/button";
import { Sheet, SheetContent, SheetHeader, SheetTitle } from "@/components/ui/sheet";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {getAllCars, getCarById} from "@/services/carService";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import RentalDialog from "@/components/RentalDialog";



const CarDetails = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [showLoginDialog, setShowLoginDialog] = React.useState(false);
  const [showRentalDialog, setShowRentalDialog] = React.useState(false);
  const [isLoggedIn, setIsLoggedIn] = React.useState(false);

  
  const { data: car, isLoading, error } = useQuery({
    queryKey: ["car", id],
    queryFn: () => getCarById(parseInt(id || "1")),
    enabled: !!id
  });

  const handleClose = () => {
    navigate("/");
  };

  const handleRentClick = () => {
    // If user is logged in, show rental dialog, otherwise show login dialog
    if (isLoggedIn) {
      setShowRentalDialog(true);
    } else {
      setShowLoginDialog(true);
    }
  };

  const handleLogin = () => {
    navigate("/login");
    setShowLoginDialog(false);
  };

  const PRICE_DISPLAY_NAMES: Record<string, string> = {
    OneToFive: "1-5 days",
    SixToForteen: "6-14 days",
    OverForteen: "Over 14 days",
    Deposit: "Deposit"
  };
  const FuelIcon = ({ fuelType }: { fuelType: string }) => {
    // Determine the icon to render based on fuelType
    const getIcon = () => {
      switch (fuelType.toLowerCase()) {
        case 'electricity':
          return <img className="h-8 w-8" alt="electricity" src="../icons/Battery.png" />;
        case 'diesel':
          return <img className="h-8 w-8" alt="diesel" src="../icons/Diesel.png" />;
        case 'hybrid':
          return <img className="h-8 w-8" alt="hybrid" src="../icons/Hybrid.png" />;
        case 'fuel':
        default:
          return <img className="h-8 w-8" alt="fuel" src="../icons/Fuel.jpg"/>;
      }
    };

    return (
        <div className="flex flex-col items-center">
          <div className="bg-gray-200 p-3 rounded-full">
            {getIcon()}
          </div>
          <span className="mt-2">{fuelType}</span>
        </div>
    );
  };

// Usage example
  const CarFuelInfo = ({ car }: { car: { specs: { fuel: string } } }) => (
      <FuelIcon fuelType={car.specs.fuel} />
  );




  if (isLoading) {
    return (
      <div className="min-h-screen flex flex-col">
        <Navbar />
        <div className="flex-grow flex items-center justify-center">
          <div className="text-gray-600">Autó adatok betöltése...</div>
        </div>
        <Footer />
      </div>
    );
  }

  if (error || !car) {
    return (
      <div className="min-h-screen flex flex-col">
        <Navbar />
        <div className="flex-grow flex items-center justify-center">
          <div className="text-red-500">Az autó nem található vagy hiba történt az adatok betöltésekor.</div>
        </div>
        <Footer />
      </div>
    );
  }

  return (
    <div className="min-h-screen flex flex-col">
      <Navbar />
      <Sheet open={true} onOpenChange={handleClose}>
        <SheetContent side="top" className="h-full w-full overflow-y-auto" style={{ maxWidth: '100%' }}>
          <div className="flex justify-end">
            <Button variant="ghost" onClick={handleClose} className="p-2">
              <X className="h-6 w-6" />
            </Button>
          </div>
          
          <div className="max-w-4xl mx-auto">
            <div className="bg-gray-200 py-2 mb-4">
              <h2 className="text-xl font-bold text-center">{car.type}</h2>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              <div className="h-64 bg-gray-200 flex items-center justify-center">
                <img src={car.picture} alt={car.type} className="h-full w-full object-contain" />
              </div>

              <Card>
                <CardHeader className="bg-blue-500 text-white">
                  <CardTitle className="text-center">Bérleti díjak</CardTitle>
                </CardHeader>
                <CardContent className="p-0">
                  <table className="w-full">
                    <tbody>
                      {Object.entries(PRICE_DISPLAY_NAMES).map(([period, price], index) => (
                        <tr key={index} className={index % 2 === 0 ? "bg-gray-200" : "bg-gray-100"}>
                          <td className="py-2 px-4">{period}</td>
                          <td className="py-2 px-4 text-right">{price} ft</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </CardContent>
              </Card>
            </div>

            <div className="mt-6">
              <div className="bg-blue-500 text-white py-2 mb-4">
                <h3 className="text-lg font-bold text-center">Gépjármű adatok</h3>
              </div>

              <div className="flex justify-center space-x-12 mb-6">

                export default CarFuelInfo;


            </div>
            </div>

            <div className="mt-8">
              <Button 
                className="w-full bg-orange-500 hover:bg-orange-600 text-white py-2 rounded"
                onClick={handleRentClick}
              >
                Gépjármű foglalás
              </Button>
            </div>

            <div className="mt-12 border-t pt-6">
              <h3 className="text-lg font-bold text-center mb-4">Kapcsolat</h3>
              <div className="flex flex-col items-center space-y-2">
                <p className="flex items-center">
                  <span className="font-bold mr-2">Tel:</span> +36-1-555-55-55
                </p>
                <p className="flex items-center">
                  <span className="font-bold mr-2">Email:</span> info@example.hu
                </p>
                <p className="flex items-center">
                  <span className="font-bold mr-2">Cím:</span> Autó kölcsönző
                </p>
              </div>
            </div>
          </div>
        </SheetContent>
      </Sheet>

      {/* Login dialog */}
      <Dialog open={showLoginDialog} onOpenChange={setShowLoginDialog}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Bejelentkezés szükséges</DialogTitle>
            <DialogDescription>
              A gépjármű foglalásához kérjük jelentkezzen be vagy regisztráljon.
            </DialogDescription>
          </DialogHeader>
          <DialogFooter className="flex flex-col sm:flex-row gap-2">
            <Button 
              variant="secondary" 
              onClick={() => setShowLoginDialog(false)}
            >
              Mégsem
            </Button>
            <Button 
              onClick={handleLogin}
            >
              Bejelentkezés
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* Rental dialog - only shows for logged in users */}
      <RentalDialog 
        open={showRentalDialog}
        onOpenChange={setShowRentalDialog}
        carName={car.type}
      />

      <Footer />
    </div>
  );
};

export default CarDetails;
