import React, { useState } from "react";
import { FaFacebookSquare } from "react-icons/fa";
import { SiGoogle } from "react-icons/si";
import { useLogin } from "../auth/UserServiceHook/useLogin";
import { Link } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const { mutate, isPending, setServerError, serverError } = useLogin();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!email || !password) {
      setServerError("Please fill in both fields.");
      return;
    }

    mutate(
      { Email: email, PasswordHash: password },
      {
        onError: (error) => {
          setServerError(error?.message || "Login failed.");
        },
      }
    );
  };

  return (
    <div className="flex items-center justify-center bg-neutral-950 h-screen w-screen text-white">
      <div className="lg:h-[80%] lg:w-[80%] h-screen w-screen bg-gradient-to-b from-neutral-900 via-gray-600 to-black rounded-xl shadow-lg p-8 md:p-14 sm:p-14">
        <div className="font-semibold lg:text-6xl text-4xl justify-self-center">
          Unlimited movies, TV <br />
        </div>
        <div className="font-semibold text-4xl justify-self-center">
          shows and more
        </div>
        <div className="text-3xl justify-self-center font-medium lg:mt-5 mt-3 tracking-wide">
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
          <form onSubmit={handleSubmit}>
            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">Email</p>
              <input
                type="email"
                className="flex-1 text-white bg-transparent focus:outline-none"
                onInput={(e) => setEmail(e.target.value)}
              />
            </div>

            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">Password</p>
              <input
                type="password"
                className="flex-1 text-white bg-transparent focus:outline-none"
                onInput={(e) => setPassword(e.target.value)}
              />
            </div>

            <div className="text-[#8B8B8B] whitespace-nowrap ml-3 mb-2">
              Click to get one time password (OTP)
            </div>

            {serverError && (
              <div className="text-red-500 ml-3 text-sm mb-2">
                {serverError}
              </div>
            )}

            <div className="w-96 bg-white text-black flex items-center justify-center font-bold h-8">
              <button type="submit" disabled={isPending}>
                {isPending ? "Logging in..." : "Login"}
              </button>
            </div>
          </form>

          <div className="w-96 bg-white text-black flex items-center justify-center font-bold h-8 mt-4">
            <Link to="/register" className="cursor-pointer">
              Dont have an account? Register
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
