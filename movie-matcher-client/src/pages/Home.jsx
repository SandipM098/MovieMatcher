import { Header } from "../components/Header";
import {Footer} from "../components/Footer";
import { Search } from "../components/Search";
import { MovieCard } from "./movies/MovieCard";

const Home = () => {
  return (
    <>
    <div className="hidden sm:block">
      <Header />
      <div className="p-10">
        <MovieCard/>
      </div>
    </div>
      <div className="block sm:hidden">
       <Search/>
        Home
        <Footer/>
      </div>
    </>
  );
};

export default Home;
