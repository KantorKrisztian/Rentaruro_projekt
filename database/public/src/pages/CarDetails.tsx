
import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { X, Fuel, CircleDot } from "lucide-react";
import Navbar from "@/components/Navbar";
import Footer from "@/components/Footer";
import { Button } from "@/components/ui/button";
import { Sheet, SheetContent, SheetHeader, SheetTitle } from "@/components/ui/sheet";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { getCarById } from "@/services/carService";

const CarDetails = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const { data: car, isLoading, error } = useQuery({
    queryKey: ["car", id],
    queryFn: () => getCarById(parseInt(id || "1")),
    enabled: !!id
  });

  const handleClose = () => {
    navigate("/");
  };

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



          <div className="max-w-4xl mx-auto">
            <div className="bg-gray-200 py-2 mb-4">
              <h2 className="text-xl font-bold text-center">{car.name}</h2>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              <div className="h-64 bg-gray-200 flex items-center justify-center">
                <img src={car.imageUrl} alt={car.name} className="h-full w-full object-contain" />
              </div>

              <Card>
                <CardHeader className="bg-blue-500 text-white">
                  <CardTitle className="text-center">Bérleti díjak</CardTitle>
                </CardHeader>
                <CardContent className="p-0">
                  <table className="w-full">
                    <tbody>
                      {Object.entries(car.priceTable).map(([period, price], index) => (
                        <tr key={index} className={index % 2 === 0 ? "bg-gray-200" : "bg-gray-100"}>
                          <td className="py-2 px-4">{period}</td>
                          <td className="py-2 px-4 text-right">{price}</td>
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
                <div className="flex flex-col items-center">
                  <div className="bg-gray-200 p-3 rounded-full">
                    <Fuel className="h-8 w-8" />
                  </div>
                  <span className="mt-2">{car.specs.fuel}</span>
                </div>

                <div className="flex flex-col items-center">
                  <div className="bg-gray-200 p-3 rounded-full">
                    <CircleDot className="h-8 w-8" />
                  </div>
                  <span className="mt-2">{car.specs.transmission}</span>
                </div>
              </div>
            </div>

            <div className="mt-8">
              <Button 
                className="w-full bg-orange-500 hover:bg-orange-600 text-white py-2 rounded"
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
      <Footer />
    </div>
  );
};

export default CarDetails;
