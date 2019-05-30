export class SearchCourse {
  name: string;
  page: number;
  pageSize: number;
  constructor(page?: number, pageSize?: number, name?: string) {
    this.page = page || 1;
    this.pageSize = pageSize || 5;
    this.name = name || "";
  }
}
