import { IRelation } from './contracts/IRelation';
import { IPodcast } from './contracts/IPodcast';

export class P2P implements IPodcast {
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
