
import React from "react";
import Navbar from "@/components/Navbar";
import Header from "@/components/Header";
import CarGrid from "@/components/CarGrid";
import Footer from "@/components/Footer";

const Index = () => {
  return (
    <div className="min-h-screen flex flex-col">
      <Navbar />
      <Header />
      <main className="flex-grow">
        <CarGrid />
      </main>
      <Footer />
    </div>
  );
};

export default Index;
