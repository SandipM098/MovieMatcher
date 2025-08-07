import { Link } from "react-router-dom";
import { IoMdHome } from "react-icons/io";
import { BiSolidVideos } from "react-icons/bi";
import { FaMasksTheater } from "react-icons/fa6";
import { VscFolderLibrary } from "react-icons/vsc";
import { FaRegUser } from "react-icons/fa";

export const Footer = () => {
  return (
    <footer className="fixed bottom-0 w-full bg-[#2B2B2B] text-white z-50">
      <nav>
        <ul className="flex justify-around items-center py-2">
          <li className="flex flex-col items-center text-xs">
            <Link to="/" className="flex flex-col items-center">
              <IoMdHome className="w-6 h-6 mb-1" />
              HOME
            </Link>
          </li>
          <li className="flex flex-col items-center text-xs">
            <Link to="/new" className="flex flex-col items-center">
              <BiSolidVideos className="w-6 h-6 mb-1" />
              NEW
            </Link>
          </li>
          <li className="flex flex-col items-center text-xs">
            <Link to="/genre" className="flex flex-col items-center">
              <FaMasksTheater className="w-6 h-6 mb-1" />
              GENRE
            </Link>
          </li>
          <li className="flex flex-col items-center text-xs">
            <Link to="/library" className="flex flex-col items-center">
              <VscFolderLibrary className="w-6 h-6 mb-1" />
              LIBRARY
            </Link>
          </li>
          <li className="flex flex-col items-center text-xs">
            <Link to="/user" className="flex flex-col items-center">
              <FaRegUser className="w-6 h-6 mb-1" />
              USER
            </Link>
          </li>
        </ul>
      </nav>
    </footer>
  );
};

