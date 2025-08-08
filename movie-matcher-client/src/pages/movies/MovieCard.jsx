import React from "react";

export const MovieCard = () => {
  return (
    <div className="border border-black h-56 w-56 rounded overflow-hidden relative group">
      <img
        alt="Movie Poster"
        className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-300"
        src="/images/default-image.webp"
      />
      <div className="absolute bottom-2 left-2 right-2 z-[900] bg-white text-black px-3 py-1 text-sm rounded shadow-lg hover:bg-gray-800 hover:text-white cursor-pointer transition-all duration-300">
        Download
      </div>
    </div>
  );
};
