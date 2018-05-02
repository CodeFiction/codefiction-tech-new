import { IContent } from './IContent';

export interface IPodcast extends IContent {
  season: number;
  soundcloudId: string;
  guest: string;
}
