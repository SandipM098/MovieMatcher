import { IoSearchOutline } from "react-icons/io5";
import { IoMic } from "react-icons/io5";
import { Link } from 'react-router-dom';
import { IoMdHome } from "react-icons/io";
import { BiSolidVideos } from "react-icons/bi";
import { FaMasksTheater } from "react-icons/fa6";
import { VscFolderLibrary } from "react-icons/vsc";
import { FaRegUser } from "react-icons/fa";
export const Header = () => {
  return (
    <>
      <div className="flex bg-[#2B2B2B] w-screen items-center text-white p-4 justify-around">
        <nav className="w-[70%] ml-4">
          <ul className="list-none flex items-center justify-evenly">
            <li>
              <Link to="/" className="cursor-pointer">
                <IoMdHome className="w-8 h-8 justify-self-center" />
                HOME
              </Link>
            </li>
            <li>
              <Link to="#" className="cursor-pointer">
                <BiSolidVideos className="w-8 h-8 justify-self-center" />
                NEW
              </Link>
            </li>
            <li>
              <Link to="/genre" className="cursor-pointer">
                <FaMasksTheater className="w-8 h-8 justify-self-center" />
                GENRE
              </Link>
            </li>
            <li>
              <Link to="/library" className="cursor-pointer">
                <VscFolderLibrary className="w-8 h-8 justify-self-center" />
                LIBRARY
              </Link>
            </li>
            <li>
              <Link to="/user" className="cursor-pointer">
                <FaRegUser className="w-8 h-8 justify-self-center" />
                USER
              </Link>
            </li>
          </ul>
        </nav>
        <div className="flex items-center gap-6 bg-[#2A2A2A] w-[25%] text-white p-4 flex-right">
          <IoSearchOutline />
          <input
            type="text"
            className="bg-[#2A2A2A] bg-transparent w-[70%]"
            placeholder="Search for movie, tv, genre etc...."
          />
          <IoMic className="flex-end cursor-pointer" />
        </div>
      </div>
    </>
  );
}
