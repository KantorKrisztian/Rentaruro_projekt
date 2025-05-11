import React from "react";
import { Link } from "react-router-dom";
import { User, Home, Search } from "lucide-react";
import { cn } from "@/lib/utils";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "@/components/ui/navigation-menu";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { useState } from 'react'


const Navbar = () => {
  const [loggedIn, setLoggedIn] = useState(false);

  const scrollToFooter = () => {
    const footer = document.querySelector('footer');
    footer?.scrollIntoView({ behavior: 'smooth' });
  };
  const [searchQuery, setSearchQuery] = useState('');
  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
  };

  const handleSearchSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    // Perform search logic or redirect with search query
    console.log("Search submitted:", searchQuery);
  };


  return (
    <nav className="w-full bg-white border-b border-gray-200">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <div className="flex-shrink-0 flex items-center">
              <span className="text-3xl font-bold text-amber-500">AUTÓ</span>
              <span className="text-3xl font-bold text-white bg-amber-500 px-2">KÖLCSÖNZŐ</span>
            </div>
            <div className="hidden sm:ml-10 sm:flex sm:space-x-8">
              <div className="flex space-x-8 ml-10">
                <Link
                  to="/"
                  className="inline-flex items-center px-1 pt-1 text-sm font-medium text-gray-900 uppercase hover:text-amber-500"
                >
                  <Home className="mr-1 w-4 h-4" />
                  Főoldal
                </Link>
                <NavigationMenu>
                  <NavigationMenuList>
                    <NavigationMenuItem>
                      <NavigationMenuTrigger className="text-sm font-medium text-gray-900 uppercase hover:text-amber-500 bg-transparent">
                        Autóink
                      </NavigationMenuTrigger>
                      <NavigationMenuContent className="bg-white p-4 shadow-lg rounded-lg w-[200px]">
                        <div className="flex flex-col space-y-2">
                          <Link
                            to="/cars/luxury"
                            className="text-sm text-gray-700 hover:text-amber-500 hover:bg-gray-50 px-3 py-2 rounded-md"
                          >
                            Luxus autók
                          </Link>
                          <Link
                            to="/cars/sports"
                            className="text-sm text-gray-700 hover:text-amber-500 hover:bg-gray-50 px-3 py-2 rounded-md"
                          >
                            Sport autók
                          </Link>
                          <Link
                            to="/cars/economy"
                            className="text-sm text-gray-700 hover:text-amber-500 hover:bg-gray-50 px-3 py-2 rounded-md"
                          >
                            Városi autók
                          </Link>
                          <Link
                            to="/cars/all"
                            className="text-sm text-gray-700 hover:text-amber-500 hover:bg-gray-50 px-3 py-2 rounded-md"
                          >
                            Összes autó
                          </Link>
                        </div>
                      </NavigationMenuContent>
                    </NavigationMenuItem>
                  </NavigationMenuList>
                </NavigationMenu>

                <Link
                  to="#contact"
                  onClick={scrollToFooter}
                  className="inline-flex items-center px-1 pt-1 text-sm font-medium text-gray-900 uppercase hover:text-amber-500"
                >
                  Kapcsolat
                </Link>
                <form onSubmit={handleSearchSubmit} className="relative">
                  <input
                      type="text"
                      value={searchQuery}
                      onChange={handleSearchChange}
                      placeholder="Search..."
                      className="block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-amber-500 focus:border-amber-500 sm:text-sm"
                  />
                  <button
                      type="submit"
                      className="absolute inset-y-0 right-0 flex items-center px-3 text-gray-500 hover:text-amber-500"
                  >
                    <Search className="h-5 w-5" />
                  </button>
                </form>
              </div>
            </div>
          </div>

          <div className="flex items-center">
            <div className="flex-shrink-0">


              <DropdownMenu>
                <DropdownMenuTrigger asChild>
                  <button className="p-2 rounded-full border-2 border-gray-300 hover:bg-gray-100 transition-colors">
                    <User className="h-6 w-6 text-gray-600" />
                  </button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-56" align="end">
                  {loggedIn? (
                    <>
                      <DropdownMenuItem>
                        <Link to="/profile" className="w-full">
                          Profil
                        </Link>
                      </DropdownMenuItem>
                      <DropdownMenuItem>
                        <Link to="/my-rentals" className="w-full">
                          Bérléseim
                        </Link>
                      </DropdownMenuItem>
                      <DropdownMenuItem>
                        <Link to="/settings" className="w-full">
                          Beállítások
                        </Link>
                      </DropdownMenuItem>
                      <DropdownMenuItem className="text-red-600">
                        <button className="w-full text-left" onClick={() => {sessionStorage.setItem('token','')
                          setLoggedIn(loggedIn => false)}}>
                          Kijelentkezés
                        </button>
                      </DropdownMenuItem>
                    </>
                  ):(
                    <>
                      <DropdownMenuItem>
                        <Link to="/login" className="w-full">
                          Bejelentkezés
                        </Link>
                      </DropdownMenuItem>
                      <DropdownMenuItem>
                        <Link to="/registration" className="w-full">
                          Regisztráció
                        </Link>
                      </DropdownMenuItem>
                    </>
                    )

                  }
                </DropdownMenuContent>
              </DropdownMenu>
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
