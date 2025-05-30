export interface Book {
   id: number;
  title: string;
  description: string;
  noOfPages: number;
  isActive: boolean;
  createdOn: Date;
  languageId: number;
  authorId: number;
}
