
import { useQuery } from "@tanstack/react-query";
import { Fuel, CircleDot, X, CalendarIcon } from "lucide-react";
import Navbar from "@/components/Navbar";
import Footer from "@/components/Footer";
import { Button } from "@/components/ui/button";
import { Sheet, SheetContent, SheetHeader, SheetTitle } from "@/components/ui/sheet";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogClose,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { format } from "date-fns";
import { Calendar } from "@/components/ui/calendar";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { cn } from "@/lib/utils";
import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";



const CarDetails = () => {
  const [showLoginDialog, setShowLoginDialog] = React.useState(false);
  const [showRentalDialog, setShowRentalDialog] = React.useState(false);
  const [showBookingDialog, setShowBookingDialog] = useState(false);
  const [startDate, setStartDate] = useState<Date | undefined>(undefined);
  const [endDate, setEndDate] = useState<Date | undefined>(undefined);

  interface Car {
    id: number;
    licensePlate: string;
    picture: string;
    brand: string;
    type: string;
    year: string;
    drive: string;
    gearShift: string;
    fuel: string;
    airCondition: boolean;
    radar: boolean;
    cruiseControl: boolean;
    info: string;
    category: string;
    OneToFive: number;
    SixToForteen: number;
    OverForteen: number;
    Deposit: number;
  }

    const {id} = useParams<{ id: string }>();
    const navigate = useNavigate();

    const [car, setCar] = useState<Car | null>(null); // Define state for a single car using the Car interface
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
  const [loggedIn, setLoggedIn] = useState(false)
  const [user, setUser] = useState();

  interface User {
    id: number;
    username: string;
    password: string;
    phone: string;
    email: string;
    name: string;
  }


  useEffect(() => {
    const tokenCheck = () => {
      const isLoggedIn = localStorage.getItem("loggedIn") === "true";
      setLoggedIn((loggedIn) => true)
    };

    tokenCheck();
  }, []);

    useEffect(() => {
      const loadCarDetails = async () => {
        try {
          const response = await fetch(`http://127.1.1.1:3000/ListCar/${id}`); // Replace with your server URL
          if (!response.ok) {
            throw new Error(`Failed to fetch car details: ${response.statusText}`);
          }
          const result: Car = await response.json();
          setCar(result); // Save the car details in state
          setLoading(false);
        } catch (err) {
          setError(err.message || "Something went wrong.");
          setLoading(false);
        }
      };

      loadCarDetails();
    }, [id]);

    const handleClose = () => {
      navigate("/");
    };

    if (loading) {
      return <p>Loading...</p>;
    }

    if (error) {
      return <p className="text-red-500">Error: {error}</p>;
    }

    if (!car) {
      return <p>No car details available.</p>;
    }


  const handleRentClick = () => {
    setShowBookingDialog(true);
    User();
  };

  function User() {
    const loadRequest = new XMLHttpRequest()
    loadRequest.open('get', 'http://127.1.1.1:3000/User')
    loadRequest.send()
    loadRequest.onreadystatechange = () => {
      if (loadRequest.readyState == 4 && loadRequest.status == 200) {
        const result = JSON.parse(loadRequest.response)
        setUser((user) => result)
      }
    }
  }
  const useer:User = user;



  function AddRent(){
    const addRequest = new XMLHttpRequest()
    addRequest.open('post','http://127.1.1.1:3000/NewRent')
    addRequest.setRequestHeader('Content-Type','Application/JSON')
    addRequest.setRequestHeader('authorization',sessionStorage.getItem('token'))
    addRequest.send(JSON.stringify({
      carId: car.id,
      id: useer.id,
      start: startDate,
      end: endDate,
      other: (document.getElementById('notes') as HTMLInputElement)?.value || '',
    }))
    addRequest.onreadystatechange = () => {
      if(addRequest.readyState == 4){
        const result = JSON.parse(addRequest.response)
        console.log(result.message)
        if(addRequest.status == 201){
          alert('Sikeres létrehozás!')
        }
      }
    }
  }


    const handleLogin = () => {
      navigate("/login");
      setShowLoginDialog(false);
    };


    const handleBookingSubmit = (e: React.FormEvent) => {
      e.preventDefault();
      setShowBookingDialog(false);
      alert("Foglalás sikeresen elküldve!");
    };

    const today = new Date();
    today.setHours(0, 0, 0, 0);

    const handleStartDateChange = (date: Date | undefined) => {
      setStartDate(date);
      if (date && endDate && date > endDate) {
        setEndDate(undefined);
      }
    };

    const calendarStyles = {
      day_disabled: "text-muted-foreground opacity-30 bg-gray-100 dark:bg-gray-800",
    };


    return (
        <div className="min-h-screen flex flex-col">
          <Navbar/>
          <Sheet open={true} onOpenChange={handleClose}>
            <SheetContent side="top" className="h-full w-full overflow-y-auto" style={{maxWidth: '100%'}}>
              <div className="flex justify-end">
                <Button variant="ghost" onClick={handleClose} className="p-2">
                  <X className="h-6 w-6"/>
                </Button>
              </div>

              <div className="max-w-4xl mx-auto">
                <div className="bg-gray-200 py-2 mb-4">
                  <h2 className="text-xl font-bold text-center">{car.type}</h2>
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div className="h-64 bg-gray-200 flex items-center justify-center">
                    <img
                        src={car.picture}
                        alt={car.brand}
                        className="h-full w-full object-cover"
                    />

                  </div>

                  <Card>
                    <CardHeader className="bg-blue-500 text-white">
                      <CardTitle className="text-center">Bérleti díjak</CardTitle>
                    </CardHeader>
                    <CardContent className="p-0">
                      <table className="w-full">
                        <tbody>
                        <tr>
                            <td className="border-t border-gray-200 py-2 px-4">1-5 nap:</td>
                          <td className="border-t border-gray-200 py-2 px-4">{car.OneToFive} ft</td>
                        </tr>
                        <tr>
                          <td className="border-t border-gray-200 py-2 px-4">6-14 nap:</td>
                          <td className="border-t border-gray-200 py-2 px-4">{car.SixToForteen} ft</td>
                        </tr>
                        <tr>
                          <td className="border-t border-gray-200 py-2 px-4">15+ nap:</td>
                          <td className="border-t border-gray-200 py-2 px-4">{car.OverForteen} ft</td>
                        </tr>
                        <tr>
                          <td className="border-t border-gray-200 py-2 px-4">Kaukció:</td>
                          <td className="border-t border-gray-200 py-2 px-4">{car.Deposit} ft</td>
                        </tr>
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

                    <h1 className="text-3xl font-bold mt-4">{car.brand} {car.type}</h1>
                    <ul className="mt-4 space-y-2">
                      <li>Évjárat: {car.year}</li>
                      <li>Meghajtás: {car.drive}</li>
                      <li>Váltó: {car.gearShift}</li>
                      <li>Üzemanyak: {car.fuel}</li>
                      <li>Légkondi: {car.airCondition ? "Van" : "Nincs"}</li>
                      <li>Tolató radar: {car.radar ? "Van" : "Nincs"}</li>
                      <li>Tempomat: {car.cruiseControl ? "Van" : "Nincs"}</li>
                    </ul>


                  </div>
                </div>

                <div className="mt-8">
                  <Button
                      className="w-full bg-orange-500 hover:bg-orange-600 text-white py-2 rounded"
                      onClick={loggedIn ? handleRentClick : handleLogin}
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

          <Dialog open={showBookingDialog} onOpenChange={setShowBookingDialog}>
            <DialogContent className="sm:max-w-md">
              <DialogHeader>
                <DialogTitle>Gépjármű foglalása</DialogTitle>
                <DialogDescription>
                  Töltse ki az alábbi adatokat a foglaláshoz.
                </DialogDescription>
              </DialogHeader>

              <form onSubmit={handleBookingSubmit} className="space-y-4">
                <div className="space-y-2">
                  <label htmlFor="startDate" className="text-sm font-medium">Bérlés kezdete</label>
                  <Popover>
                    <PopoverTrigger asChild>
                      <Button
                          id="startDate"
                          variant={"outline"}
                          className={cn(
                              "w-full justify-start text-left font-normal",
                              !startDate && "text-muted-foreground"
                          )}
                      >
                        <CalendarIcon className="mr-2 h-4 w-4" />
                        {startDate ? format(startDate, "yyyy-MM-dd") : "Válasszon dátumot"}
                      </Button>
                    </PopoverTrigger>
                    <PopoverContent className="w-auto p-0" align="start">
                      <Calendar
                          mode="single"
                          selected={startDate}
                          onSelect={handleStartDateChange}
                          disabled={(date) => date < today}
                          initialFocus
                          className="pointer-events-auto"
                          classNames={calendarStyles}
                      />
                    </PopoverContent>
                  </Popover>
                </div>

                <div className="space-y-2">
                  <label htmlFor="endDate" className="text-sm font-medium">Bérlés vége</label>
                  <Popover>
                    <PopoverTrigger asChild>
                      <Button
                          id="endDate"
                          variant={"outline"}
                          className={cn(
                              "w-full justify-start text-left font-normal",
                              !endDate && "text-muted-foreground"
                          )}
                      >
                        <CalendarIcon className="mr-2 h-4 w-4" />
                        {endDate ? format(endDate, "yyyy-MM-dd") : "Válasszon dátumot"}
                      </Button>
                    </PopoverTrigger>
                    <PopoverContent className="w-auto p-0" align="start">
                      <Calendar
                          mode="single"
                          selected={endDate}
                          onSelect={setEndDate}
                          disabled={(date) =>
                              date < today || (startDate ? date < startDate : false)
                          }
                          initialFocus
                          className="pointer-events-auto"
                          classNames={calendarStyles}
                      />
                    </PopoverContent>
                  </Popover>
                </div>

                <div className="space-y-2">
                  <label htmlFor="notes" className="text-sm font-medium">Egyéb megjegyzés</label>
                  <Textarea
                      id="notes"
                      placeholder="Egyéb igények és megjegyzések..."
                      className="w-full h-24"
                  />
                </div>

                <DialogFooter className="flex flex-col sm:flex-row gap-2">
                  <DialogClose asChild>
                    <Button variant="outline">Mégsem</Button>
                  </DialogClose>
                  <Button
                      onClick={AddRent}
                      type="submit"
                      disabled={!startDate || !endDate}

                  >
                    Foglalás
                  </Button>
                </DialogFooter>
              </form>
            </DialogContent>
          </Dialog>

          <Footer/>
        </div>
    );
  };

export default CarDetails;
