export interface Book {
  message: string;
  id: number | 0;               // required, non-nullable
  title: string;            // required
  description: string;      // required
  noOfPages: number;        // required
  isActive: boolean;        // required
  createdOn: string | Date; // backend expects Date, frontend can handle ISO string or Date object
  languageId: number;       // required
  language?: Language;      // optional full Language object
  authorId?: number | null; // optional and nullable - match backend's int? AuthorId
  author?: Author;          // optional full Author object
}
export interface contact {
  id:number;
  message: string;
  name:string;
  email:string;
}

export interface Language {
  id: number;
  name: string;
}

export interface Author {
  id: number;
  name: string;
}
