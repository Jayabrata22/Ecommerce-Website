export type Pagination<T> = {
    pageIndex : Number;
    pageSize: number;
    coubt: number;
    data: T[];
}