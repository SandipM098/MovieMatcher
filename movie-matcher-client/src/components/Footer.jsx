import React from "react";
import { Link } from "react-router-dom";

const Footer = () => {
  return (
    <>
      <nav className="">
        <ul className="list-none">
          <li>
            <Link to="/">HOME</Link>
          </li>
          <li>
            <Link to="#">New</Link>
          </li>
          <li>
            <Link to="/genre">GENRE</Link>
          </li>
          <li>
            <Link to="/library">LIBRARY</Link>
          </li>
          <li>
            <Link to="/user">USER</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

export default Footer;
