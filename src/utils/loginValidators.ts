import { ref } from "vue";

//用户账号数据接口
// 用户账号数据类型定义
interface User {
  userName: string;
  password: string;
}

//类型匹配与输出
export const loginUser = ref<User>({
  userName: "",
  password: "",
});


// 校验规则接口
interface Rules {
  userName: {
    type: string;
    message: string;
    required: boolean;
    trigger: string;
  }[];
  password: ({
    required: boolean;
    message: string;
    trigger: string;
    min?: undefined;
    max?: undefined;
  } | {
    min: number;
    max: number;
    message: string;
    trigger: string;
    required?: undefined;
  })[];
}

export const rules = ref<Rules>({
  userName: [
    {
      type: "userName",
      message: "userName is incorrect...",
      required: true,
      trigger: "blur",
    },
  ],
  password: [
    //密码存在规则
    {
      required: true,
      message: "Password could not be empty...",
      trigger: "blur",
    },
    //密码长度规则
    {
      min: 6,
      max: 30,
      message: "Password's length has to be 6 to 30 characters...",
      trigger: "blur",
    },
  ],
});