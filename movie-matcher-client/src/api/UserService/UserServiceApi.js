import apiInstance from "../axios";

export const loginApi = async (loginData) => {
  try {
    const response = await apiInstance.post("auth/login", loginData);
    return response.data;
  } catch (error) {
    console.error("Validation Errors:", error.response.data);
    throw error.response.data ?? new Error("Login failed");
  }
};
