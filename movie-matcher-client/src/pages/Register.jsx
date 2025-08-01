import React, { useState } from 'react'
import { FaFacebookSquare } from "react-icons/fa";
import { SiGoogle } from "react-icons/si";
import { Link } from 'react-router-dom';
import { useRegister } from '../auth/UserServiceHook/useRegister';

const Register = () => {
  const [form, setForm] = useState({ UserName : '', Email: '', PasswordHash: '', ConfirmPassword: ''});
  const {mutate, isPending, setServerError, serverError} = useRegister();
  const handleChange = (e) => {
    setForm((prev)=> ({
      ...prev,
      [e.target.name]: e.target.value
    }))
  }


  const handleSubmit = (e) => {
    e.prevent.default();
    mutate({
      form
    }, 
    {
      onError: (error)=>{
        setServerError(error?.message || 'Registration failed');
      }
    }
    )
  }
  return (
    <div className="flex items-center justify-center bg-neutral-950 h-screen w-screen text-white">
      <div className="h-[80%] w-[80%] bg-gradient-to-b from-neutral-900 via-gray-600 to-black rounded-xl shadow-lg p-8">
        <div className="font-semibold text-6xl justify-self-center">
          Unlimited movies, TV <br />
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
          <form onSubmit={handleSubmit}>
            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">Username</p>
              <input
                type="text"
                className="flex-1 text-white bg-transparent focus:outline-none"
                name="UserName"
                value={form.UserName}
                onChange={handleChange}
              />
            </div>

            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">Email</p>
              <input
                type="email"
                className="flex-1 text-white bg-transparent focus:outline-none"
                name="Email"
                value={form.Email}
                onChange={handleChange}
              />
            </div>

            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">Password</p>
              <input
                type="password"
                className="flex-1 text-whites bg-transparent focus:outline-none"
                name="PasswordHash"
                value={form.PasswordHash}
                onChange={handleChange}
              />
            </div>

            <div className="flex items-end gap-2 w-96 border-b border-[#8B8B8B] pb-1 mb-3">
              <p className="text-[#8B8B8B] whitespace-nowrap ml-2">
                RePassword
              </p>
              <input
                type="password"
                className="flex-1 text-white bg-transparent focus:outline-none"
                name="ConfirmPassword"
                value={form.ConfirmPassword}
                onChange={handleChange}
              />
            </div>

            {serverError && (
              <div className="text-red-500 ml-3 text-sm mb-2">
                {serverError}
              </div>
            )}

            <div className="w-96 bg-white text-black flex items-center justify-center font-bold h-8">
              <button type="submit" disabled={isPending}>
                {isPending ? "Registering in..." : "Register"}
              </button>
            </div>
          </form>

          <div className="w-96 bg-white text-black flex items-center justify-center font-bold h-8 mt-4">
            <Link to="/login" className="cursor-pointer">
              Have an account? SingIn
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Register