import React from 'react'
import { IoSearchOutline } from "react-icons/io5";
import { IoMic } from "react-icons/io5";
export const Search = () => {
  return (
    <>
      <div className="flex items-center gap-6 bg-[#2A2A2A] w-screen text-white p-6">
        <IoSearchOutline className="" />
        <input
          type="text"
          className="bg-[#2A2A2A] bg-transparent focus:outline-none"
          placeholder="Search for movie, tv, gene etc...."
        />
        <IoMic className="flex-end" />
      </div>
    </>
  );
}
