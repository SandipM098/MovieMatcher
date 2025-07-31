import { loginApi } from "../../api/UserService/UserServiceApi";
import { useMutation } from "@tanstack/react-query";

export const useLogin = () => {
    return useMutation({
        mutationFn: loginApi,
        onSuccess: () => {
            console.log("Successfull login");
        },
        onError: (error) => {
            console.error("Login failed:", error.message || error);
        }
    })
}