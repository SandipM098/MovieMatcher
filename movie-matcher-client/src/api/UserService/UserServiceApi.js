import apiInstance from "../axios";

export const loginApi = async (loginData) => {
  try {
    const response = await apiInstance.post("auth/login", loginData);
    return response.data;
  } catch (error) {
    console.error("Validation Errors:", error);
    throw error ?? new Error("Login failed");
  }
};

export const registerApi = async (registerData) => {
  try {

  } catch (error) {
    console.log("Validation error :" . error );
    throw error ?? new Error("Registration failed")
  }
}