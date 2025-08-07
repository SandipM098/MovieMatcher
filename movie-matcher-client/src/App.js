import {Routes, Route, BrowserRouter } from "react-router-dom"
import Home from "./pages/Home.jsx";
import Register from "./pages/Register.jsx";
import Login from "./pages/Login.jsx";
import { Search } from "./components/Search.jsx";
import { Header } from "./components/Header.jsx";
import { PageNotFound } from "./pages/PageNotFound.jsx";

export const App = () => {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login/>}></Route>
          <Route path="/register" element={<Register/>}></Route>
          <Route path="/" element={<Home/>}></Route>
          <Route path='/search' element={<Search/>}/>
          <Route path="/header" element={<Header/>}/>
          <Route path="*" element={<PageNotFound/>}/>
        </Routes>
      </BrowserRouter>
    </>
  );
}
