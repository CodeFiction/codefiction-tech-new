import { IRelation } from './IRelation';

export interface IContent {
  id: number;
  title: string;
  slug: string;
  youtubeUrl: string;
  shortDescription: string;
  longDescription: string;
  attendees: string[];
  tags: string[];
  relation: IRelation[];
  publishDate: Date;
}
