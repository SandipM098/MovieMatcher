import { IoSearchOutline } from "react-icons/io5";
import { IoMic } from "react-icons/io5";
export const Search = () => {
  return (
    <>
      <div className="flex items-center bg-[#2B2B2B] w-full text-white p-3 justify-around">
        <div className="flex items-center gap-3 w-[75%]">
          <IoSearchOutline className="" />
          <input
            type="text"
            className="bg-[#2B2B2B] bg-transparent focus:outline-none w-[90%]"
            placeholder="Search for movie, tv, genre etc...."
          />
        </div>
        <IoMic/>
      </div>
    </>
  );
}
