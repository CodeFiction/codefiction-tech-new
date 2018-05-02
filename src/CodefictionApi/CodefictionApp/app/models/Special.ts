import { IPodcast } from './contracts/IPodcast';
import { IRelation } from './contracts/IRelation';

export class Special implements IPodcast {
  season: number;
  soundcloudId: string;
  guest: string;
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
