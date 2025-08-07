import { Header } from "../components/Header";
import Footer from "../components/Footer.jsx";
const Home = () => {
  return (
    <>
    <div className="hidden sm:block">
      <Header />
      <div>Home</div>
    </div>
      <div className="block sm:hidden">

        Home
        <Footer/>
      </div>
    </>
  );
};

export default Home;
