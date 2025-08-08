import { Header } from "../components/Header";
import {Footer} from "../components/Footer";
import { Search } from "../components/Search";
import { MovieCard } from "./movies/MovieCard";

const Home = () => {
  return (
    <>
      <div className="hidden sm:block">
        <Header />
        <div className="p-10 grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6 gap-6">
          {Array.from({ length: 10 }).map((_, i) => (
            <MovieCard key={i} />
          ))}
        </div>
      </div>
      <div className="block sm:hidden">
        <Search />
        <div className="p-10 grid grid-cols-2 gap-6">
          {Array.from({ length: 10 }).map((_, i) => (
            <MovieCard key={i} />
          ))}
        </div>
        <Footer />
      </div>
    </>
  );
};

export default Home;
