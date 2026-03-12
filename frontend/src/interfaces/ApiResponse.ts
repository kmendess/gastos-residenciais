export interface ApiResponse<T> {
  data: T;
  isSuccess: boolean;
  messages: string[];
}