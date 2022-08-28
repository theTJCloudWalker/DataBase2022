import { ref } from "vue";

// 用户账号数据类型定义
interface Buyer {
    BuyerName: string;
    phone: string;
    email:string;
  }
  
  //类型匹配与输出
  export const BuyerInfo = ref<Buyer>({
    BuyerName: "",
    phone: "",
    email:""
  });