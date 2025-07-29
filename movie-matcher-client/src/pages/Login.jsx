import React, {useState} from "react";

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

        <div>
          <div>Login with facebook</div>
          <div>Login with Google</div>
        </div>
        <span>or</span>
        <div>
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
