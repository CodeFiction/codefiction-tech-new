import { IRelation } from './Relation';

export interface IPodcast {
    id: number;
    slug: string;
    soundcloudUrl: string;
    youtubeUrl: string;
    shortDescription: string;
    longDescription: string;
    attendees: string[];
    tags: string[];
    relation: IRelation[];
}