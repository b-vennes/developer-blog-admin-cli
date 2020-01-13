use reqwest;
use serde::{Deserialize, Serialize};
use clap::{Arg, App, SubCommand};

fn main() {
    let matches = App::new("Developer Blog CLI")
        .version("0.1")
        .about("Allows communication with a developer blog backend API.")
        .subcommand(SubCommand::with_name("content")
            .about("Retrieves the blog's current contents."))
        .subcommand(SubCommand::with_name("publish")
            .about("Publishes new blog content."))
        .get_matches();

    match matches.subcommand() {
        ("content", Some(_)) => handle_content_command(),
        ("publish", Some(_)) => handle_publish_command(),
        _ => println!("subcommand not found")
    };
}

#[derive(Serialize, Deserialize, Debug)]
struct PublishDto {
    id: String,
    title: String,
    url: String,
    format: String,
    hidden: String
}

#[derive(Serialize, Deserialize, Debug)]
struct ContentOverviewDto {
    id: String,
    title: String,
    publishedDate: String
}

fn handle_content_command() {
    let overviews = get_content_overviews();

    match overviews {
        Ok(o) => println!("{:?}", o),
        Err(err) => println!("Error retrieving overviews! Error: {}", err)
    }
}

fn handle_publish_command() {
    println!("Publishing not yet implemented!");
}

fn get_content_overviews() -> Result<Vec<ContentOverviewDto>, reqwest::Error> {
    let response = reqwest::blocking::get("http://localhost:5000/api/content")?;

    println!("{:?}", response);

    let overviews = response.json::<Vec<ContentOverviewDto>>()?;

    return Ok(overviews);
}