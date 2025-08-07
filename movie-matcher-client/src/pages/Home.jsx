import { Header } from "../components/Header";
import {Footer} from "../components/Footer";
import { Search } from "../components/Search";

const Home = () => {
  return (
    <>
    <div className="hidden sm:block">
      <Header />
      <div>Home</div>
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
