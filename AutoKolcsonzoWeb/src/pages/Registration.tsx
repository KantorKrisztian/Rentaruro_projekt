
import React from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { X } from "lucide-react";
import { useState } from 'react'

const Registration = () => {
  const navigate = useNavigate();

  const handleClose = () => {
    navigate("/");
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    navigate("/");
  };
    function registration(){
      const registrationRequest = new XMLHttpRequest()
      registrationRequest.open('post','http://127.1.1.1:3000/UserRegistration')
      registrationRequest.setRequestHeader('Content-Type','Application/JSON')
      registrationRequest.send(JSON.stringify({
        registerNev: (document.getElementById('registerNev') as HTMLInputElement).value,
        registerPassword: (document.getElementById('registerPassword') as HTMLInputElement).value,
        registerPhone: (document.getElementById('registerPhone') as HTMLInputElement).value,
        registerEmail: (document.getElementById('registerEmail') as HTMLInputElement).value,
        registerName: (document.getElementById('registerName') as HTMLInputElement).value
      }))
      registrationRequest.onreadystatechange = () => {
        if(registrationRequest.readyState == 4 && registrationRequest.status == 200){
          const result = JSON.parse(registrationRequest.response)
          sessionStorage.setItem('token',result.token)
        }
      }
    }


  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <Card className="w-full max-w-md mx-4">
        <CardHeader className="relative border-b">
          <Button
            variant="ghost"
            className="absolute right-4 top-4"
            onClick={handleClose}
          >
            <X className="h-4 w-4" />
          </Button>
          <CardTitle className="text-xl font-bold text-center">
            Regisztráció
          </CardTitle>
        </CardHeader>
        <CardContent className="pt-6">
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="space-y-2">
              <Input
                type="text"
                placeholder="Felhasználó név"
                id="registerNev"
                className="w-full"
              />
            </div>
            <div className="space-y-2">
              <Input
                type="email"
                placeholder="Email cím"
                id="registerEmail"
                className="w-full"
              />
            </div>
            <div className="space-y-2">
              <Input
                  type="text"
                  placeholder="Telefonszám"
                  id="registerPhone"
                  className="w-full"
              />
            </div>
            <div className="space-y-2">
              <Input
                  type="text"
                  placeholder="Teljes név"
                  id="registerName"
                  className="w-full"
              />
            </div>
            <div className="space-y-2">
              <Input
                type="password"
                placeholder="Jelszó"
                id="registerPassword"
                className="w-full"
              />
            </div>
            <Button type="submit" className="w-full bg-amber-500 hover:bg-amber-600" onClick={registration}>
              Regisztráció
            </Button>
            <p className="text-center text-sm text-gray-600">
              Már van fiókja?{" "}
              <Button
                variant="link"
                className="p-0 h-auto font-semibold text-amber-500 hover:text-amber-600"
                onClick={() => navigate("/login")}
              >
                Jelentkezzen be
              </Button>
            </p>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

export default Registration;
