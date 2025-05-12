
import React from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { X, UserX } from "lucide-react";
import { useState } from 'react'


const Login = () => {
  const navigate = useNavigate();


  const handleClose = () => {
    navigate("/");
  };
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    navigate("/");
  };

  function login(){
    const loginRequest = new XMLHttpRequest()
    loginRequest.open('post','http://127.1.1.1:3000/UserLogin')
    loginRequest.setRequestHeader('Content-Type','Application/JSON')
    loginRequest.send(JSON.stringify({
      loginNev: (document.getElementById('loginUsername') as HTMLInputElement).value,
      loginPassword: (document.getElementById('loginPassword') as HTMLInputElement).value
    }))
    loginRequest.onreadystatechange = () => {
      if(loginRequest.readyState == 4 && loginRequest.status == 200){
        const result = JSON.parse(loginRequest.response)
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
            Bejelentkezés
          </CardTitle>
        </CardHeader>
        <CardContent className="pt-6">
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="space-y-2">
              <Input
                type="text"
                placeholder="Felhasználó név"
                className="w-full"
                id="loginUsername"
              />
            </div>
            <div className="space-y-2">
              <Input
                type="password"
                placeholder="Jelszó"
                className="w-full"
                id="loginPassword"
              />
            </div>
            <Button type="submit" className="w-full bg-amber-500 hover:bg-amber-600" onClick={login}>
              Bejelentkezés
            </Button>
            <p className="text-center text-sm text-gray-600">
              Még nincs fiókja?{" "}
              <Button
                variant="link"
                className="p-0 h-auto font-semibold text-amber-500 hover:text-amber-600"
                onClick={() => navigate("/registration")}
              >
                Regisztráljon
              </Button>
            </p>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

export default Login;
