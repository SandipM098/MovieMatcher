import { useMutation } from "@tanstack/react-query"
import { registerApi } from "../../api/UserService/UserServiceApi"
export const useRegister = ()=> {
    return useMutation({
        mutationFn: registerApi,
        onSuccess: ()=>
        {
            console.log("Successfully registered");
        },
        onError: (error)=>{
            console.error("Registration failed:", error.message || error);
        }
    });
}