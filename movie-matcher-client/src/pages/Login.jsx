import React, {useState} from "react";
import { FaFacebookSquare } from "react-icons/fa";
import { SiGoogle } from "react-icons/si";

const Login = () => {
  const [mobile, setMobile] = useState("");
  const [otp, setOtp] = useState("");
  return (
    <div className="flex items-center justify-center bg-neutral-950 h-screen w-screen text-white">
      <div className="h-[80%] w-[80%] bg-gradient-to-b from-neutral-900 via-gray-600 to-black rounded-xl shadow-lg p-8">
        <div className="font-semibold text-6xl justify-self-center">
          Unlimited movies, TV <br></br>
        </div>
        <div className="font-semibold text-4xl justify-self-center">
          shows and more
        </div>
        <div className="text-3xl justify-self-center font-medium mt-5 tracking-wide">
          Watch anywhere. Cancel anytime.
        </div>

        <div className="justify-self-center mt-6">
          <div className="flex items-center border border-blue-900 w-96 rounded-lg h-10 mb-3 cursor-pointer">
            <div className="bg-blue-950 w-[25%] h-full flex items-center justify-center rounded-l-lg">
              <FaFacebookSquare className="h-6 w-6 text-white" />
            </div>
            <div className="text-white h-full rounded-r-lg w-[75%] font-medium text-xl bg-blue-800 ">
              <p className="text-center">Login with Facebook</p>
            </div>
          </div>
          <div className="flex items-center border border-gray-500 w-96 rounded-lg h-10 cursor-pointer">
            <div className="h-full w-[25%]  flex items-center justify-center rounded-l-lg bg-orange-800">
              <SiGoogle className="h-5 w-5 text-white" />
            </div>
            <div className="text-white h-full rounded-r-lg w-[75%] font-medium text-xl bg-orange-700 ">
              <p className="text-center">Login with Google</p>
            </div>
          </div>
        </div>

        <div className="justify-self-center mt-3 mb-3 text-xl font-bold">
          or
        </div>

        
        <div className="justify-self-center">
          <form action="">
            <input
              type="text"
              className="text-black"
              onInput={(e) => setMobile(e.target.value)}
              placeholder="Mobile No."
            />
            <br />
            <input
              type="text"
              className="text-black"
              onInput={(e) => setOtp(e.target.value)}
              placeholder="OTP"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;
