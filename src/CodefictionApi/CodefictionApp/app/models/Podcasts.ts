import { IRelation } from './Relation';

export interface IPodcast {
    id: number;
    title: string;
    slug: string;
    soundcloudId: string;
    youtubeUrl: string;
    shortDescription: string;
    longDescription: string;
    attendees: string[];
    tags: string[];
    relation: IRelation[];
    publishDate: Date;
}