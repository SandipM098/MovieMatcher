import React from "react";

export const MovieCard = () => {
  return (
    <div className="relative border border-black h-60 w-60 rounded overflow-hidden">
      <img
        alt="Movie Poster"
        className="w-full h-full object-cover"
        src="/images/default-image.webp"
      />

      <div className="absolute bottom-2 right-2 z-[900] bg-white text-black px-3 py-1 text-sm rounded shadow-lg hover:bg-gray-800 cursor-pointer transition">
        Download
      </div>
    </div>
  );
};
