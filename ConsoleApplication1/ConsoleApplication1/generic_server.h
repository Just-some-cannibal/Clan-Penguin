#pragma once
#include <memory>
#include <vector>
#include <thread>

#include <boost/asio.hpp>


template <typename handler>
class generic_server
{
	using shared_handler_t = std::shared_ptr<handler>;
public:
	generic_server(int thread_count = 1, uint16_t port = 4000)
		: thread_count_(thread_count),
		acceptor_(io_service_),
		port_(port)
		{};
	void start_server();
private:
	void handle_new_connection(shared_handler_t handler,
		const boost::system::error_code & error);
	int thread_count_;
	uint16_t port_;
	std::vector<std::thread> thread_pool_;
	boost::asio::io_service io_service_;
	boost::asio::ip::tcp::acceptor acceptor_;
};


